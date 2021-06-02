export async function handleLogin(e, {username, password}, {isLoading, setIsLoading}) {
	e.preventDefault();
	setIsLoading(true);

	//replace this with the api call
	const data = await setTimeout(() => {
		setIsLoading(false);
	}, 2000);

	//complete the logic & useContext
}
