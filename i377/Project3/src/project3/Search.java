package project3;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Arrays;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import project3.dao.CustomerDao;
import project3.model.Customer;

public class Search extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    public Search() {
        super();
        // TODO Auto-generated constructor stub
    }

	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		String searchString = request.getParameter("searchString");
		String action = request.getParameter("do");
		String code = request.getParameter("code");
		
		if (action!=null && action.equals("delete")) {
			new CustomerDao().destroy(code);
			response.sendRedirect("Search");
			return;
		}
		
		
		List<Customer> customers = new CustomerDao().
				setSearch(searchString).
				all();
		request.setAttribute("customers", customers);
		
		request.getRequestDispatcher("WEB-INF/jsp/Search.jsp").forward(request, response);
	}

}
