import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import {BrowserRouter as Router} from "react-router-dom";
import {IsLoadingProvider} from "./Context/IsLoadingContext";
import {UserProvider} from './Context/UserContext'

ReactDOM.render(
	<React.StrictMode>
		<Router>
			<IsLoadingProvider>
			<UserProvider>
			<App />
			</UserProvider>
			</IsLoadingProvider>
		</Router>
	</React.StrictMode>,
	document.getElementById("root")
);
