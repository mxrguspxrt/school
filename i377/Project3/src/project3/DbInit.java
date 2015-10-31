package project3;

import java.io.File;
import java.net.URL;

import org.apache.tools.ant.Project;
import org.apache.tools.ant.taskdefs.SQLExec;


import javax.servlet.*;

public class DbInit implements ServletContextListener {
	
	static String DB_URL = "jdbc:hsqldb:mem:db_mpart";
	
	@Override
	public void contextDestroyed(ServletContextEvent event) {
		System.out.println("Bye");
	}
	
	@Override
	public void contextInitialized(ServletContextEvent event) {
		System.out.println("Hello");
		
		this.createSchema();
	}
	
	
	// Next is copy-paste from
	// https://bitbucket.org/mkalmo/exjdbc/src/af14369730d0bd515a358698783b0eced62fb939/src/main/java/ex3/dao/SetupDao.java?at=master
	
    public void createSchema() {
        executeSqlFromFile(getClassPathFile("db_init.sql"));
    }

    private String getClassPathFile(String fileName) {
        URL url = getClass().getClassLoader().getResource(fileName);
        if (url == null) {
            throw new IllegalStateException("can't find " + fileName);
        }

        return getClass().getClassLoader().getResource(fileName).getFile();
    }

    private void executeSqlFromFile(String sqlFilePath) {

        Project project = new Project();
        project.init();

        SQLExec e = new SQLExec();
        e.setProject(project);
        e.setTaskType("sql");
        e.setTaskName("sql");
        e.setSrc(new File(sqlFilePath));
        e.setDriver("org.hsqldb.jdbcDriver");
        e.setUserid("sa");
        e.setPassword("");
        e.setUrl(DB_URL);
        e.execute();
    }

}
