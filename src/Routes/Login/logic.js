import {CONNECTION_ISSUE, INVALID_CREDENTIALS} from "../../Helper/Constants";
import {EMPTY_INPUT} from "../../Helper/Constants";

export async function handleLogin(props, e, {username, password}, setErrorMessage, {isLoading, setIsLoading}, {user, setUser}) {
	e.preventDefault();

	if (username === "" || password === "") await setErrorMessage(EMPTY_INPUT);
	else {
		setIsLoading(true);

		try {
			//api call
			const requestOptions = {
				method: "POST",
				headers: {"Content-Type": "application/json"},
				body: JSON.stringify({Username: username, Password: password}),
			};

			const response = await fetch("http://localhost:3001/api/user/validate", requestOptions);

			if (response?.status === 200) {
				await setUser({username, password});
				await setErrorMessage("");
				//redirect to account page
				props.history.push("/main");
			} else await setErrorMessage(INVALID_CREDENTIALS);
		} catch {
			setErrorMessage(CONNECTION_ISSUE);
		}

		setTimeout(() => {
			setIsLoading(false);
		}, 1000);
	}
}
