package projekt2;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class HomePage extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		HttpSession session = request.getSession(true);
		String param = request.getParameter("param");
		
		if (param!=null)
			session.setAttribute("param", param);
		
		
		PrintWriter responder = response.getWriter();
		responder.println("Hello");
		responder.println("Session id: " + session.getId());
		responder.println("Session attribute: " + session.getAttribute("param"));
		
	}

}
