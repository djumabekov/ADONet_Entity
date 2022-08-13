<Query Kind="Expression">
  <Connection>
    <ID>2fc4bdc7-59b2-4db7-8b3d-6651f8061cfa</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>LAPTOP-66IDD8T0\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Countries</Database>
  </Connection>
</Query>

//Отобразить всю информацию о странах;
//from c in Countries select c

//Отобразить название стран;
//from c in Countries select c.Country

//Отобразить название столиц;
//from c in Countries select c.Capital

//Отобразить название всех евразийских стран;
//from c in Countries where c.Materic == "Евразия" select c.Country

//Отобразить название стран с площадью большей конкретного числа.
//from c in Countries where c.Area > 10000000 select c.Country

//Отобразить все страны, у которых в названии есть буквы а, у;
//from c in Countries where c.Country.Contains("а") || c.Country.Contains("у") select c.Country

//Отобразить все страны, у которых название начинается с буквы А;
//from c in Countries where c.Country.StartsWith("А") select c.Country

//Отобразить название стран, у которых площадь находится в указанном диапазоне;
//from c in Countries where c.Area > 600000 && c.Area < 100000000 select new {c.Country, c.Area}

//Отобразить название стран, у которых количество жителей больше указанного числа.
//from c in Countries where c.Population > 900000000 select new {c.Country, c.Population}

//Показать топ-5 стран по площади;
//(from c in Countries  orderby c.Area descending select new {c.Country, c.Area}).Take(5)

//Показать топ-5 стран по количеству жителей;
//(from c in Countries  orderby c.Population descending select new {c.Country, c.Population}).Take(5)

//Показать страну с самой большой площадью;
//(from c in Countries  orderby c.Area descending select new {c.Country, c.Area}).Take(1)

//Показать страну с самым большим количеством жителей;
//(from c in Countries  orderby c.Population descending select new {c.Country, c.Population}).Take(1)

//Показать страну с самой маленькой площадью в Африке;
//(from c in Countries where c.Materic == "Африка" orderby c.Area ascending select new {c.Country, c.Materic, c.Area}).Take(1)

//Показать среднюю площадь стран в Евразии.
(from c in Countries select c.Area).Average()

