import React, { useState } from "react";
import "./register.css";
import {Link} from "react-router-dom";
import {handleRegister} from './logic.js'
import {useIsLoading} from '../../Context/IsLoadingContext.js'

export default function Register() {
         
	const [form,setForm] = useState({username:"",password:"",confirmPassword:""})
    const isLoadingState = useIsLoading();

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
					<button onClick={e => handleRegister(e,form,isLoadingState)}>Become a Member</button>
					<Link to="/">
						<p className="redirectMessage">Already a Member? How about you sign in!</p>
					</Link>
				</form>
			</div>
		</div>
	);
}
