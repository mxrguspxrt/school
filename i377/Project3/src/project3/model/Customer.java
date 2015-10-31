package project3.model;

public class Customer {
	
	int id;
	String firstName;
	String surname;
	String code;
	
	public Customer(String firstName, String surname, String code) {
		this.firstName = firstName;
		this.surname = surname;
		this.code = code;
	}
	
	public Customer() {
		
	}
	
	public Customer setId(Integer id) {
		this.id = id;
		return this;
	}

	public Customer setFirstName(String firstName) {
		this.firstName = firstName;
		return this;
	}
	
	public Customer setSurname(String surname) {
		this.surname = surname;
		return this;
	}
	
	public Customer setCode(String code) {
		this.code = code;
		return this;
	}
	
	public int getId() {
		return this.id;
	}
	
	public String getFirstName() {
		return this.firstName;
	}

	public String getSurname() {
		return this.surname;
	}

	public String getCode() {
		return this.code;
	}
	
    @Override
    public String toString() {
        return "Customer [firstName=" + firstName + ", surname=" + surname + ", code=" + code + "]";
    }


}
