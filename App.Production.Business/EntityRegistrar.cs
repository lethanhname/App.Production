

using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF.Data;
using App.Production.Contract;

namespace App.Production.Business
{
    public class EntityService
    {
        public static void RegisterEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemColor>(etb =>
              {
                  etb.HasKey(e => e.Code);
                  etb.Property(e => e.RowVersion).IsConcurrencyToken();
                  etb.ToTable("INV_Color");
              }
            );

            modelBuilder.Entity<Inseam>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_Inseam");
             }
           );
            modelBuilder.Entity<Waist>(etb =>
                    {
                        etb.HasKey(e => e.Code);
                        etb.Property(e => e.RowVersion).IsConcurrencyToken();
                        etb.ToTable("INV_Waist");
                    }
                  );

            modelBuilder.Entity<Unit>(etb =>
                   {
                       etb.HasKey(e => e.Code);
                       etb.Property(e => e.RowVersion).IsConcurrencyToken();
                       etb.ToTable("INV_Unit");
                   }
                 );
            modelBuilder.Entity<Warehouse>(etb =>
                  {
                      etb.HasKey(e => e.Code);
                      etb.Property(e => e.RowVersion).IsConcurrencyToken();
                      etb.ToTable("INV_Warehouse");
                  }
                );

            modelBuilder.Entity<StockGroup>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_StockGroup");
             }
           );


            modelBuilder.Entity<StockType>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.StockGroupCode);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_StockType");
             }
           );
            modelBuilder.Entity<ItemCategory>(etb =>
              {
                  etb.HasKey(e => e.Code);
                  etb.HasIndex(e => e.StockTypeCode);
                  etb.Property(e => e.RowVersion).IsConcurrencyToken();
                  etb.ToTable("INV_ItemCategory");
              }
            );

            modelBuilder.Entity<ItemClass>(etb =>
                    {
                        etb.HasKey(e => e.Code);
                        etb.HasIndex(e => e.StockTypeCode);
                        etb.Property(e => e.RowVersion).IsConcurrencyToken();
                        etb.ToTable("INV_ItemClass");
                    }
                  );
            modelBuilder.Entity<ItemClassCategory>(etb =>
                    {
                        etb.HasKey(e => new { e.ItemClassCode, e.ItemCategoryCode });
                        etb.HasIndex(e => e.ItemClassCode);
                        etb.HasIndex(e => e.ItemCategoryCode);
                        etb.Property(e => e.RowVersion).IsConcurrencyToken();
                        etb.ToTable("INV_ItemClassCategory");
                    }
                  );


            modelBuilder.Entity<ProductService>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.ItemCategoryCode);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_ProductService");
             }
           );


            modelBuilder.Entity<ProductServiceValue>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.ProductServiceCode);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_ProductServiceValue");
             }
           );

            modelBuilder.Entity<ItemCategoryAttribute>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.ItemCategoryCode);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_ItemCategoryAttribute");
             }
           );

            modelBuilder.Entity<ItemCategoryAttributeValue>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.ItemAttributeCode);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_ItemCategoryAttributeValue");
             }
           );

            modelBuilder.Entity<ItemSize>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.WaistCode);
                 etb.HasIndex(e => e.InseamCode);
                 etb.HasIndex(e => e.ItemCategoryCode);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_ItemSize");
             }
           );

            modelBuilder.Entity<InventoryItem>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.AlternateCode);
                 etb.HasIndex(e => e.BaseUnit);
                 etb.HasIndex(e => e.SaleUnit);
                 etb.HasIndex(e => e.PurchaseUnit);
                 etb.HasIndex(e => e.WeightUnit);
                 etb.HasIndex(e => e.VolumeUnit);
                 etb.HasIndex(e => e.ItemClassCode);
                 etb.HasIndex(e => e.ItemCategoryCode);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_InventoryItem");
             }
           );
           modelBuilder.Entity<InventorySubItem>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.ColorCode);
                 etb.HasIndex(e => e.SizeCode);
                 etb.HasIndex(e => e.SerialNo);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("INV_InventorySubItem");
             }
           );

           modelBuilder.Entity<Techpack>(etb =>
             {
                 etb.HasKey(e => e.Code);
                 etb.HasIndex(e => e.CustomerCode);
                 etb.HasIndex(e => e.SeasonCode);
                 etb.HasIndex(e => e.StyleCode);
                 etb.HasIndex(e => e.FabricCode);
                 etb.HasIndex(e => e.WashCode);
                 etb.HasIndex(e => e.ProductType);
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("PRO_Techpack");
             }
           );

            modelBuilder.Entity<TechpackRev>(etb =>
             {
                 etb.HasKey(e => new{ e.Code, e.RevNo});                
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("PRO_TechpackRev");
             }
           );

           modelBuilder.Entity<TechpackLine>(etb =>
             {
                 etb.HasKey(e => new{ e.Code, e.RevNo, e.LineNbr});                
                 etb.Property(e => e.RowVersion).IsConcurrencyToken();
                 etb.ToTable("PRO_TechpackLine");
             }
           );
        }
    }
}