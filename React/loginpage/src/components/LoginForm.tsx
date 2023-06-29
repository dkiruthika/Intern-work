import React, { useState } from 'react';
import img1 from '../images/img1.png';

const LoginForm = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [usernameError, setUsernameError] = useState('');
  const [passwordError, setPasswordError] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const validateUsername = () => {
    setUsernameError('');

    if (username.trim() === '') {
      setUsernameError('Username is required');
      return false;
    }

    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(username)) {
      setUsernameError('Invalid email format');
      return false;
    }

    return true;
  };

  const validatePassword = () => {
    setPasswordError('');

    if (password.trim() === '') {
      setPasswordError('Password is required');
      return false;
    }

    if (password.length < 8) {
      setPasswordError('Password should be at least 8 characters');
      return false;
    }

    return true;
  };

  const validateForm = (event:React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const isUsernameValid = validateUsername();
    const isPasswordValid = validatePassword();

    if (isUsernameValid && isPasswordValid) {
      // Perform form submission or further actions
      console.log('Form submitted');
    }
  };

  return (
    <div className="login-container">
      <div className="company-info">
      <img src={img1} alt="Company Logo" style={{ width: '100%' }} />
        <h5>Powered by Toast•© Toast, Inc. 2023. All Rights Reserved.•Privacy Statement•Terms of Service•Toast Blog</h5>
      </div>

      <div className="login-form">
        <form className="loginForm" id="loginForm" onSubmit={validateForm}>
          <h2>Login</h2>
          <div className="form-group">
            <label htmlFor="Username">Username</label>
            <input
              type="text"
              className="form-control"
              id="Username"
              placeholder="Username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              onBlur={validateUsername}
            />
            <span className="text-danger">{usernameError}</span>
          </div>
          <div className="form-group">
            <label htmlFor="Password">Password</label>
            <input
              type="password"
              className="form-control"
              id="Password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              onBlur={validatePassword}
            />
            <span className="text-danger">{passwordError}</span>
          </div>
          <button type="submit" className="btn btn-primary">Login</button>
        </form>

        {errorMessage && (
          <div>
            <br />
            <div className="alert alert-danger">{errorMessage}</div>
          </div>
        )}
      </div>
    </div>
  );
};

export default LoginForm;
