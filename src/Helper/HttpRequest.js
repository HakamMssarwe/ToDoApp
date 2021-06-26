import axios, {AxiosError, AxiosResponse} from "axios";

export default async function HttpRequest(url, method, data) {
	return axios
		.request({
			url: url,
			baseURL: API_URL,
			method: method,
			data: data,
		})
		.then((result: AxiosResponse) => {
			return Promise.resolve(result);
		})
		.catch((err: AxiosError) => {
			return Promise.reject(err.response);
		});
}
