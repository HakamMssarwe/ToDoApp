import React from "react";
import "./login.css";
import {Link} from "react-router-dom";
import {handleLogin} from "./logic.js";
import {useState} from "react";
import {useIsLoading} from '../../Context/IsLoadingContext.js'

export default function Login() {
	const [form, setForm] = useState({username: "", password: ""});
    const isLoadingState = useIsLoading()

	return (
		<div className="Login">
			<div className="left-child">
				<img src="LoginBackground.svg" alt="backgroundImage" />
			</div>
			<div className="right-child">
				<form>
					<label for="username">What do we call you?</label>
					<input id="username" type="text" value={form.username} onChange={e => setForm(prevState => ({...prevState, username: e.target.value}))}></input>
					<label for="password">What's our secret?</label>
					<input id="password" type="password" value={form.password} onChange={e => setForm(prevState => ({...prevState, password: e.target.value}))}></input>
					<button onClick={e => handleLogin(e,form,isLoadingState)}>Next</button>
					<Link to="/register">
						<p className="redirectMessage">Not a Member? How about you join us!</p>
					</Link>
				</form>
			</div>
		</div>
	);
}
