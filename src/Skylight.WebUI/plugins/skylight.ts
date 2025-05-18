import axios from 'axios';
import type { AxiosInstance } from 'axios';
import type { RuntimeConfig } from 'nuxt/schema';
import { SkylightClient } from '~/clients/skylight';

export const SkylightApi = Symbol() as InjectionKey<SkylightClient>;

export default defineNuxtPlugin((nuxtApp) => {
	nuxtApp.vueApp.use((app) => {
		const config: RuntimeConfig = useRuntimeConfig();
		const client: AxiosInstance = axios.create({
			timeout: 1000,
			transformResponse: (data) => data, // Axios might auto-parse the JSON, which would cause errors in the NSwag client when trying to parse again
		});

		client.interceptors.request.use((request) => {
			console.log(`Sending HTTP request to ${request.url}: ${request.data}`);

			return request;
		});

		if (config.public.logging.clients) {
			client.interceptors.request.use(
				(request) => {
					console.log(`Sending HTTP request to ${request.url}: ${request.data}`);

					return request;
				},
				(error) => {
					console.error(`Failed to send HTTP request to ${error.config.url}: ${error}`);

					return Promise.reject(error);
				},
			);

			client.interceptors.response.use(
				(response) => {
					console.log(
						`Receiving HTTP response from ${response.config.url}: ${response.status} ${response.statusText} ${response.data}`,
					);

					return response;
				},
				(error) => {
					console.log(`Failed to receive HTTP response from ${error.config.url}: ${error}`);

					return Promise.reject(error);
				},
			);
		}

		const api = new SkylightClient(config.public.apiBaseSkylight, client);

		app.provide(SkylightApi, api);
	});
});
