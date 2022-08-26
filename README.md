# Kusto Query Builder

Kusto Query Builder is a powerful query builder for the Kusto query language written in C#. It was inspired by the SqlKata project.

It provides a fluent based API for building Kusto queries in code. At this point it supports the following expressions:
- Project
- Where, including where between and where in
- Order by ascending and descending

## Examples

### Create a query

```cs
var qry = new Query("Table");
```

### Compile a query

```cs
var qry = new Query("Table").Compile();
```

### Project columns

```cs
var qry = new Query("Table").Project("Col1", "Col2");
```

### Where

```cs
var qry = new Query("Table").Where("Col1", "ABC");
```

### Where specifying the operator

```cs
var qry = new Query("Table").Where("Col1", "!=", "ABC");
```

### Where in a list of values

```cs
var qry = new Query("Table").WhereIn("Col1", new[] { "A", "B", "C" });
```

### Where between two date values

```cs
var qry = new Query("Table").WhereBetween("Col1", new DateTime(2022, 1, 1), new DateTime(2022, 6, 30));
```

### Where not between two date values

```cs
var qry = new Query("Table").WhereNotBetween("Col1", new DateTime(2022, 1, 1), new DateTime(2022, 6, 30));
```

### Order by ascending

```cs
var qry = new Query("Table").OrderBy("Col1", "Col2");
```

### Order by descending

```cs
var qry = new Query("Table").OrderByDesc("Col1", "Col2");
```
