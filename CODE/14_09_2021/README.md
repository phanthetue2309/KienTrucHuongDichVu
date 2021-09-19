# EntityState in Entity Framework

## Change tracking
- 4 status : 
    + Unchanged
    + Insert , Update, Delete

## Conventions 
- Change structure of DB 

## Entity 
- Class maps to a database table
- 1 thuộc tính thuộc dạng DbSet<TEntity> trong lớp DbContext => Tập thực thể 
- Gồm 2 loại thuộc tính : 
    + Scalar properties (tương ứng với các column trong CSDL)
    + Navigation Properties (thuộc tính quan hệ)
        - Reference Navigation Property : 1-1 
        - Collection Navigation Property: 1-n