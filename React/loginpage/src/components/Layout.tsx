import React from 'react';
import 'tailwindcss/tailwind.css';

const LoginPage = () => {
 
  return (
    <html>
      <head>
        
        {/* Add your custom CSS files here */}
        {/* Add your custom styles here */}
        <style>
          {`
            .login-container {
              display: flex;
            }
            
            .login-container .company-info {
              flex: 1;
              background-color: #f1f1f1;
              padding: 20px;
            }
            
            .login-container .company-info h2 {
              color: #333;
              margin-bottom: 10px;
            }
            
            .login-container .company-info p {
              color: #777;
            }
            
            .login-container .login-form {
              flex: 1;
              padding: 20px;
            }
            
            .form-group {
              margin-bottom: 10px;
            }
            
            .form-control {
              width: 100%;
              padding: 10px;
              font-size: 16px;
            }
            
            .btn-primary {
              background-color: #007bff;
              color: #fff;
              border: none;
              padding: 10px 20px;
              font-size: 16px;
              cursor: pointer;
            }
            
            .navigation-links {
              list-style-type: none;
              font-size: 26px;
              margin: 0;
              padding: 10px 0;
              display: flex;
              background-color: #2a2323;
            }
            
            .navigation-links li {
              margin-right: 70px;
            }
            
            .navigation-links li:last-child {
              margin-right: 0;
            }
            
            .navigation-links li a {
              text-decoration: none;
              color: #f1f1f1;
            }
            
            .alert {
              padding: 15px;
              margin-bottom: 20px;
              border: 1px solid transparent;
              border-radius: 4px;
            }
            
            .alert-danger {
              color: #a94442;
              background-color: #f2dede;
              border-color: #ebccd1;
              text-align: center;
            }
            
            .login-container {
              display: flex;
              align-items: center;
            }
            
            .company-info {
              margin-right: 20px;
            }
            
            .login-form {
              flex-grow: 1;
            }
          `}
        </style>
      </head>
      <body>
      <section className="bg-purple-100 rounded-2xl py-2">hi
        <div className="navbar navbar-inverse navbar-fixed-top">
          <div className="container">
            <div className="navbar-collapse collapse">
              <ul className="navigation-links" style={{ color: '#f1f1f1' }}>
                <li >Toast</li>
                <li>Home</li>
                <li >About</li>
                <li>Contact</li>
              </ul>
            </div>
          </div>
        </div>
        </section>
        <div className="login-container">
          <div className="login-form">
          
          </div>
        </div>
      </body>
    </html>
  );
};

export default LoginPage;
