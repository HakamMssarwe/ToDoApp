import React, { useState } from "react";
import "./register.css";
import {Link, withRouter} from "react-router-dom";
import {handleRegister} from './logic.js'
import {useIsLoading} from '../../Context/IsLoadingContext.js'


function Register(props) {
         
	const [form,setForm] = useState({username:"",password:"",confirmPassword:""})
	const [errorMessage, setErrorMessage] = useState("");
    const isLoadingContext = useIsLoading();


	return (
		<div className="Register">
			<div className="left-child">
				<img src="RegisterBackground.svg" alt="backgroundImage" />
			</div>
			<div className="right-child">
				<form>
					<label for="username">What should we call you?</label>
					<input id="username" type="text" value={form.username} onChange={e => setForm(prevState => ({...prevState, username: e.target.value}))}></input>
					<label for="password">Tell us a secret!</label>
					<input id="password" type="password" value={form.password} onChange={e => setForm(prevState => ({...prevState, password: e.target.value}))}></input>
					<label for="confirmPassword">Let us make sure we heard right!</label>
					<input id="confirmPassword" type="password" value={form.confirmPassword} onChange={e => setForm(prevState => ({...prevState, confirmPassword: e.target.value}))}></input>
					<p className="errorMessage">{errorMessage}</p>
					<button onClick={e => handleRegister(props,e,form,setErrorMessage,isLoadingContext)}>Become a Member</button>
					<Link to="/">
						<p className="redirectMessage">Already a Member? How about you sign in!</p>
					</Link>
				</form>
			</div>
		</div>
	);
}

export default withRouter(Register);