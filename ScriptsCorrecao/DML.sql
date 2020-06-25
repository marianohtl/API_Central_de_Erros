USE ErrorMonitoring;
GO

INSERT INTO ENVIRONMENTS(EnvName) VALUES('Produção'), ('Homologação'),('Dev');
INSERT INTO PROJECTS(pName,IsMobile,IsWeb,IsDesktop) VALUES ('Sistema de Ensino Poli',1,1,1),('Pets',1,1,0),('Estoque Magazine Ana',0,0,1);
INSERT INTO PROJECTS_ENVIRONMENTS(Project,Environment) VALUES(1,1),(1,2),(1,3),(2,1),(2,2),(3,3);
INSERT INTO EVENTS(eStatus,eLevel,eOrigin,eDate,eMessage,eDescription,eException) VALUES(
'500',
'ERROR',
'127.0.0.1',
'2020-05-12',
'message java.lang.NullPointerException',
'description The server encountered an internal error that prevented it from fulfilling this request.', 
'org.apache.jasper.JasperException: java.lang.NullPointerException org.apache.jasper.servlet.JspServletWrapper.handleJspException(JspServletWrapper.java:549) org.apache.jasper.servlet.JspServletWrapper.service(JspServletWrapper.java:470) org.apache.jasper.servlet.JspServlet.serviceJspFile(JspServlet.java:390) org.apache.jasper.servlet.JspServlet.service(JspServlet.java:334) javax.servlet.http.HttpServlet.service(HttpServlet.java:72
root cause
[code]
java.lang.NullPointerException
Class.DAOJogos.consultarJogos(DAOJogos.java:53)
org.apache.jsp.grid_jsp._jspService(grid_jsp.java:84)
org.apache.jasper.runtime.HttpJspBase.service(HttpJspBase.java:70)
javax.servlet.http.HttpServlet.service(HttpServlet.java:72
org.apache.jasper.servlet.JspServletWrapper.service(JspServletWrapper.java:432)
org.apache.jasper.servlet.JspServlet.serviceJspFile(JspServlet.java:390)
org.apache.jasper.servlet.JspServlet.service(JspServlet.java:334)
javax.servlet.http.HttpServlet.service(HttpServlet.java:72
note The full stack trace of the root cause is available in the Apache Tomcat/7.0.33 logs.
Apache Tomcat/7.0.33 [/code]');

INSERT INTO LOGS( Project, EventType, Archived) VALUES(1 ,1,0);


