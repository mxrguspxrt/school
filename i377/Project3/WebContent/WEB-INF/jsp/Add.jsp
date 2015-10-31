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



<form method="post" action="Add">
    <table class="formTable" id="formTable">
      <tbody>
        <tr>
          <td>Eesnimi:</td>
          <td><input name="firstName" id="firstNameBox"></td>
        </tr>
        <tr>
          <td>Perekonnanimi:</td>
          <td><input name="surname" id="surnameBox"></td>
        </tr>
        <tr>
          <td>Kood:</td>
          <td><input name="code" id="codeBox"></td>
        </tr>
        <tr>
          <td colspan="2" align="right"><br>
            <input type="submit" value="Lisa" id="addButton">
          </td>
        </tr>
      </tbody>
    </table>
  </form>





</body></html>