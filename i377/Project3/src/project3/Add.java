package project3;

import java.io.IOException;

import java.util.Arrays;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import project3.model.*;
import project3.dao.*;


public class Add extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    public Add() {
        super();
    }

	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setAttribute("numbers", Arrays.asList(1, 2, 3));
		request.getRequestDispatcher("WEB-INF/jsp/Add.jsp").forward(request, response);
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		Customer customer = new Customer().
				setFirstName(request.getParameter("firstName")).
				setSurname(request.getParameter("surname")).
				setCode(request.getParameter("code"));
		
		CustomerDao customerDao = new CustomerDao();
		customerDao.create(customer);
		
		response.sendRedirect("Search");
	}

}
