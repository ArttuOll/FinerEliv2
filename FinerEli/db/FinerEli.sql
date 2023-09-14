create table main.ComponentUnits
(
    Description     TEXT not null
        constraint PK_ComponentUnits
            primary key,
    EufdNameThsCode TEXT not null
);

create table main.ComponentValues
(
    FoodId          TEXT not null,
    EufdNameThsCode TEXT not null,
    Value           REAL not null,
    constraint PK_ComponentValues
        primary key (FoodId, EufdNameThsCode)
);

create table main.EufdNames
(
    ThsCode     TEXT not null
        constraint PK_EufdNames
            primary key,
    Description TEXT not null
);

create table main.Foods
(
    Id   INTEGER not null
        constraint PK_Foods
            primary key autoincrement,
    Name TEXT    not null
);

create table ComponentClasses
(
    Name        TEXT not null
        constraint PK_ComponentClasses
            primary key,
    Description TEXT not null
);

create table Components
(
    EufdNameThsCode    TEXT not null,
    ComponentUnitName  TEXT not null,
    ComponentClassName TEXT not null,
    constraint PK_Components
        primary key (EufdNameThsCode, ComponentUnitName, ComponentClassName)
);