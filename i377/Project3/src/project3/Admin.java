package project3;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import project3.dao.CustomerDao;
import project3.model.Customer;

public class Admin extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    public Admin() {
        super();
    }

	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String action = request.getParameter("do");
		
		if (action!=null && action.equals("clear_data")) {
			new CustomerDao().destroyAll();
		}
				
		if (action!=null && action.equals("insert_data")) {
			List<Customer> customers = new ArrayList<Customer>();
			
			customers.add(new Customer("Jane", "Doe", "123"));
			customers.add(new Customer("Jack", "Doe", "456"));
			customers.add(new Customer("John", "Smith", "789"));
			
			for (Customer customer : customers) {
				new CustomerDao().create(customer);
			}
		}
		
		response.sendRedirect("Search");
		

	}

}
