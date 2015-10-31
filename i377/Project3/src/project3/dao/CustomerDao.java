package project3.dao;

import java.util.ArrayList;
import java.util.List;

import project3.model.*;

import java.sql.*;


public class CustomerDao {
	
    static {
        try {
            Class.forName("org.hsqldb.jdbcDriver");
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
    };
	
	// static String DB_URL = "jdbc:hsqldb:mem:db_mpart";
    static String DB_URL = "jdbc:hsqldb:mem:db_mpart";
    
    String search = "";
    
    public CustomerDao setSearch(String search) {
    	this.search = search;
    	return this;
    }
	
	public List<Customer> all() {
		List<Customer> customers = new ArrayList<Customer>();
		
		try {
			Connection con = DriverManager.getConnection(DB_URL);
			PreparedStatement stmt;
			
			if (this.search!=null && this.search.length()>0) {
				stmt = con.prepareStatement(
						"select * from customer where (UPPER(first_name) like UPPER(?) or UPPER(surname) like UPPER(?))");
				stmt.setString(1, "%"+this.search+"%");
				stmt.setString(2, "%"+this.search+"%");				
			} else {
				stmt = con.prepareStatement("select * from customer");
			}
			ResultSet result = stmt.executeQuery();
			
			while (result.next()) {
				Customer customer = new Customer().
						setId(result.getInt("id")).
						setFirstName(result.getString("first_name")).
						setSurname(result.getString("surname")).
						setCode(result.getString("code"));
				customers.add(customer);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
		return customers;
	}
	
	public Customer findById(int id) {
		Customer customer = null;
		
		try {
			Connection con = DriverManager.getConnection(DB_URL);
			PreparedStatement stmt = con.prepareStatement("select * from customer where id=?");
			stmt.setInt(1, id);
			ResultSet result = stmt.executeQuery();
			result.first();
			
			customer = new Customer().
					setId(result.getInt("id")).
					setFirstName(result.getString("first_name")).
					setSurname(result.getString("surname")).
					setCode(result.getString("code"));

		} catch (SQLException e) {
			e.printStackTrace();
		}
		
		return customer;
	}
	
	public void create(Customer customer) {
		try {
			Connection con = DriverManager.getConnection(DB_URL);
			PreparedStatement stmt = con.prepareStatement(
					"insert into customer(id, first_name, surname, code) values(NEXT VALUE FOR seq1, ?, ?, ?)",
					Statement.RETURN_GENERATED_KEYS);
			
			stmt.setString(1, customer.getFirstName());
			stmt.setString(2, customer.getSurname());
			stmt.setString(3, customer.getCode());
			int id = stmt.executeUpdate();
			
			customer.setId(id);
			
		} catch (SQLException e) {
			e.printStackTrace();
		}	
	}
	
	public void destroy(Customer customer) {

		try {
			Connection con = DriverManager.getConnection(DB_URL);
			PreparedStatement stmt = con.prepareStatement(
					"delete customer where id=?");
			
			stmt.setInt(1, customer.getId());
			stmt.executeUpdate();
			
			customer.setId(null);
			
		} catch (SQLException e) {
			e.printStackTrace();
		}	
		
	}
	
	public void destroy(String code) {

		try {
			Connection con = DriverManager.getConnection(DB_URL);
			PreparedStatement stmt = con.prepareStatement(
					"delete from customer where code=?");
			
			stmt.setString(1, code);
			stmt.executeUpdate();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}	
		
	}

	public void destroyAll() {

		try {
			Connection con = DriverManager.getConnection(DB_URL);
			PreparedStatement stmt = con.prepareStatement(
					"delete from customer");
			
			stmt.executeUpdate();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}	
		
	}

}
