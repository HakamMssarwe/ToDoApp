import {USERNAME_TAKEN, INVALID_USERNAME, PASSWORDS_NOT_MATCH, SHORT_PASSWORD, PASSWORD_LENGTH, EMPTY_INPUT, USERNAME_LENGTH, SHORT_USERNAME, CONNECTION_ISSUE} from "../../Helper/Constants";

export async function handleRegister(props, e, {username, password, confirmPassword}, setErrorMessage, {isLoading, setIsLoading}) {
	e.preventDefault();

	//validation

	if (username === "" || password === "") await setErrorMessage(EMPTY_INPUT);
	else if (username.length < USERNAME_LENGTH) await setErrorMessage(SHORT_USERNAME);
	else if (!/^[a-zA-Z]+$/.test(username)) await setErrorMessage(INVALID_USERNAME);
	else if (password.length < PASSWORD_LENGTH) await setErrorMessage(SHORT_PASSWORD);
	else if (password !== confirmPassword) await setErrorMessage(PASSWORDS_NOT_MATCH);
	else {
		setIsLoading(true);

		try {
			//api call
			const requestOptions = {
				method: "POST",
				headers: {"Content-Type": "application/json"},
				body: JSON.stringify({Username: username, Password: password}),
			};

			const response = await fetch("http://localhost:3001/api/user/create", requestOptions);

			if (response?.status === 200) {
				await setErrorMessage("");
				//redirect to main page
				props.history.push("/");
			} else await setErrorMessage(USERNAME_TAKEN);
		} catch {
			setErrorMessage(CONNECTION_ISSUE);
		}

		setTimeout(() => {
			setIsLoading(false);
		}, 1000);
	}
}
