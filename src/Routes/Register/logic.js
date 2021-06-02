export async function handleRegister(e, {username, password, confirmPassword}, {isLoading, setIsLoading}) {
	e.preventDefault();
	setIsLoading(true);

	//Data-check logic here

	//replace this with the api call
	const data = await setTimeout(() => {
		setIsLoading(false);
	}, 2000);
}
