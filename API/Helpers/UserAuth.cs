using System.Security.Cryptography;
using System.Text;

namespace API.Helpers
{
	public static class UserAuth
	{
		public static string EncryptionKey = "mY#SeCuRe@EnCrYpTiOn$KeY2024*OK!";
		//public static string EncryptSec(string plainText, string key)
		public static string EncryptSec(string plainText)
		{
			try
			{
				// Validate input
				if (string.IsNullOrEmpty(plainText))
					throw new ArgumentNullException(nameof(plainText), "Plain text cannot be null or empty.");

				if (string.IsNullOrEmpty(EncryptionKey) || EncryptionKey.Length < 16)
					throw new ArgumentException("Key must be at least 16 characters long.");

				// Convert key to 16-byte array
				byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16));

				using (Aes aes = Aes.Create())
				{
					aes.Key = keyBytes;
					aes.GenerateIV(); // Create a random IV for this encryption

					using (MemoryStream ms = new MemoryStream())
					{
						// Write the IV at the beginning of the memory stream
						ms.Write(aes.IV, 0, aes.IV.Length);

						using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
						{
							// Encrypt the plain text
							byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
							cs.Write(inputBytes, 0, inputBytes.Length);
							cs.FlushFinalBlock();
						}

						// Return the result as a Base64 string
						return Convert.ToBase64String(ms.ToArray());
					}
				}
			}
			catch (Exception ex)
			{
				// Handle exceptions securely (e.g., log them)
				return $"Error: {ex.Message}";
			}
		}

		public static string DecryptSec(string encryptedText)
		//public static string DecryptSec(string encryptedText, string key)
		{
			try
			{
				if (string.IsNullOrEmpty(encryptedText))
					throw new ArgumentNullException(nameof(encryptedText), "Encrypted text cannot be null or empty.");

				if (string.IsNullOrEmpty(EncryptionKey) || EncryptionKey.Length < 16)
					throw new ArgumentException("Key must be at least 16 characters long.");

				byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16));
				byte[] cipherBytes = Convert.FromBase64String(encryptedText);

				using (Aes aes = Aes.Create())
				{
					aes.Key = keyBytes;

					// Extract the IV from the start of the cipherBytes
					byte[] iv = new byte[aes.BlockSize / 8];
					Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
					aes.IV = iv;

					// Extract the ciphertext
					byte[] actualCipher = new byte[cipherBytes.Length - iv.Length];
					Array.Copy(cipherBytes, iv.Length, actualCipher, 0, actualCipher.Length);

					using (MemoryStream ms = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
						{
							cs.Write(actualCipher, 0, actualCipher.Length);
							cs.FlushFinalBlock();
						}

						return Encoding.UTF8.GetString(ms.ToArray());
					}
				}
			}
			catch (Exception ex)
			{
				// Handle exceptions securely (e.g., log them)
				return $"Error: {ex.Message}";
			}
		}
	}

}
