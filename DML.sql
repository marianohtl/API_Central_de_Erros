USE ErrorMonitoring;
GO

INSERT INTO ENVIRONMENTS(EnvironmentName) VALUES('Produção'), ('Homologação'),('Dev');
INSERT INTO TECNOLOGYS(TecnologyName,TecnologyDescription) VALUES('C#', 'version 3.1, install: JWT, Xamarin, Windows Forms'),('JavaScript','version 5.2, install: npm, grunt, nodemon'),('Java', 'Framework Spring'),('Flutter', 'flutter pub get');
INSERT INTO PROJECTS(ProjectName,IsMobile,IsWeb,IsDesktop) VALUES ('Sistema de Ensino Poli',1,1,1),('Pets',1,1,0),('Estoque Magazine Ana',0,0,1);
INSERT INTO PROJECTS_ENVIRONMENTS(Project,Environment) VALUES(1,1),(1,2),(1,3),(2,1),(2,2),(3,3);
INSERT INTO PROJECTS_TECNOLOGYS(Project,TecnologyProg) VALUES(1,1),(1,2),(1,4),(2,4),(3,2);
INSERT INTO USERS(UserName ,CPF,Email,UserHash,Contact,Gender,IsAdmin) VALUES('Renata Stavia','1111111111','rStavia@gmail.com','123@Renata','2606-8222','FEMININO',0),('Aline Ribeiro','2222222222','aRibeiro@gmail.com','123@Ribeiro','2333-2288','FEMININO',0),('Lucas Eduardo','3333333333','lEduardo@gmail.com','123@Lucas','2222-2222','MASCULINO',1),('Erica Bernardes','4444444444','eBernardes@gmail.com','123@Erica','1244-2343','FEMININO',0);
INSERT INTO PROJECTS_USERS(Project, Responsible) VALUES(1,1),(1,2),(1,3),(2,2),(2,4);

INSERT INTO EVENTS(EventStatus,EventLevel,EventOrigin,EventDate,EventMessage,EventDescription,EventException) VALUES(
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

INSERT INTO LOGS(Responsible, Project, EventType, LogFile) VALUES(1, 1 ,1,0);


