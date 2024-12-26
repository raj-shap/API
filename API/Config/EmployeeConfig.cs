//using API.Models.Employee;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace API.Config
//{
//    public class EmployeeConfig : IEntityTypeConfiguration<EmployeeDetails>
//    {
//        public void Configure(EntityTypeBuilder<EmployeeDetails> builder)
//        {
//            builder.ToTable("EmployeeDetails");
//            builder.HasKey(x => x.Id);
            
//            builder.Property(x=> x.Id).UseIdentityColumn();

//            builder.Property(n=>n.UserName).IsRequired();
//            builder.Property(n=>n.FirstName).IsRequired();
//            builder.Property(n=>n.MiddleName).IsRequired();
//            builder.Property(n=>n.LastName).IsRequired();
//            builder.Property(n=>n.Email).IsRequired();
//            builder.Property(n=>n.Dob).IsRequired();
//            builder.Property(n=>n.Address).IsRequired();
//            builder.Property(n=>n.City).IsRequired();
//            builder.Property(n=>n.State).IsRequired();
//            builder.Property(n=>n.Country).IsRequired();
//            builder.Property(n=>n.PostalCode).IsRequired();
//            builder.Property(n=>n.Phone).IsRequired();
//            builder.Property(n=>n.EmergencyContactName).IsRequired();
//            builder.Property(n=>n.EmergencyContact).IsRequired();
//            builder.Property(n=>n.Department).IsRequired(false);
//            builder.Property(n=>n.Position).IsRequired(false);
//            builder.Property(n=>n.ReportTo).IsRequired(false);
//            builder.Property(n=>n.EmployeementType).IsRequired();
//            builder.Property(n=>n.Status).IsRequired();
//            builder.Property(n=>n.StartDate).IsRequired();
//            builder.Property(n=>n.CreatedOn).IsRequired(false);
//            builder.Property(n=>n.CreatedBy).IsRequired(false);
//            builder.Property(n=>n.ModifiedOn).IsRequired(false);
//            builder.Property(n=>n.ModifiedBy).IsRequired(false);

//        }
//    }
//}
