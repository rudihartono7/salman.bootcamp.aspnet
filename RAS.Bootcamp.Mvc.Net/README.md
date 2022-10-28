## Database First
Reverse Database PostgreSQL

Install .net cli dan ef (Entity Framework) cli

https://learn.microsoft.com/en-us/ef/core/cli/dotnet

Tambahkan package baru untuk koneksi ke database yaitu EF/EntityFrameworkCore 

`dotnet add package Microsoft.EntityFrameworkCore`

Tambahkan package kedua provider database pake postgreSQL

`dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`

Reverse engineering untuk database/EF dengan menambahkan package build design 

`dotnet add package Microsoft.EntityFrameworkCore.Design`

Siapkan connection string 
`Server={hostname}; Port=5432; Database={Your database}; User Id={username}; Password={password};`

jalankan command berikut ini untuk memulai proses scafolding
`dotnet ef dbcontext scaffold "Server={hostname}; Port=5432; Database={Your database}; User Id={username}; Password={password};" Npgsql.EntityFrameworkCore.PostgreSQL --context-dir Datas --output-dir "Datas/Entities" --force`

dotnet ef dbcontext scaffold "Server=localhost; Port=5432; Database=MWorkforceDb; User Id=postgres; Password=root;" Npgsql.EntityFrameworkCore.PostgreSQL --context-dir Datas --output-dir "Datas/Entities" --force

## Code First
Install .net cli dan ef cli

Tambahkan package baru untuk koneksi ke database yaitu EF/EntityFrameworkCore 

`dotnet add package Microsoft.EntityFrameworkCore`

Tambahkan package kedua untuk menghubungkan code (aspnet core) ke database PostgreSQL dengan command berikut:

`dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`

Reverse engineering untuk database/EF dengan menambahkan package build design 

`dotnet add package Microsoft.EntityFrameworkCore.Design`

run command add initial migrations 

`dotnet ef migrations add "InitialDb" -o "Models/Migrations"`

apply migration ke database dengan perintah

`dotnet ef database update`

more information about ef code first: https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx

1. Create dockerfile
2. run command for build image docker 
`docker build . -t {image_name}:{tagging}`
`docker image build . -t rasbootcampmvc:1.0`

3. docker image tag {local_image_path or name} docker.io/{nama}/{name and tag}

` docker image tag rasbootcampmvc:1.0 docker.io/rudihartono/rasbootcampmvc:1.0`

4. docker image push docker.io/{nama}/{name and tag}
`docker image push  docker.io/rudihartono/rasbootcampmvc:1.0`


Deployment AspNet Core 6
1. OS 
Terminal -> aplikasi aspnet core base nya console app using kestrel
2. Application Server -> aplikasi yang digunakan untuk menjalankan web
 - IIS
 - NGINX
 - APACHE
3. Docker
