<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
         pageEncoding="ISO-8859-1"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>

<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<title>Part 3</title>
	
	<style type="text/css">
	<!--
	@import url("/static/style.css");
	-->
	</style>
	<style type="text/css"></style>
	
</head>
<body>


<ul id="menu">
    <li><a href="Search" id="menu_Search">Otsi</a></li>
    <li><a href="Add" id="menu_Add">Lisa</a></li>
    <li><a href="Admin?do=clear_data" id="menu_ClearData">Tühjenda</a></li>
    <li><a href="Admin?do=insert_data" id="menu_InsertData">Sisesta näidisandmed</a></li>
</ul>

<br><br><br>



<form method="get" action="Search">
  <input name="searchString" id="searchStringBox" value="">
  <input type="submit" id="filterButton" value="Filtreeri">
<br><br>
<table class="listTable" id="listTable">
    <thead>
      <tr>
          <th scope="col">Nimi</th>
          <th scope="col">Perekonnanimi</th>
          <th scope="col">Kood</th>
          <th scope="col"></th>
        </tr>
    </thead>
    <tbody>

    
<c:forEach var="customer" items="${customers}">
	<tr>
		<td id="row_${customer.code}">${customer.firstName} </td>
		<td>${customer.surname} </td>
		<td>${customer.code} </td>
		<td><a href="Search?do=delete&code=${customer.code}" id="delete_${customer.code}">Delete</a></td>
    </tr>
</c:forEach>
    

    </tbody>
</table>
</form>


</body></html>