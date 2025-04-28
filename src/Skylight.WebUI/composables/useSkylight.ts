import axios, { type AxiosInstance } from 'axios';
import type { RuntimeConfig } from 'nuxt/schema';
import { SkylightClient } from '~/clients/Skylight';

export default function (): { api: SkylightClient } {
	const config: RuntimeConfig = useRuntimeConfig();
	const client: AxiosInstance = axios.create({
		timeout: 1000,
		transformResponse: (data) => data, // Axios might auto-parse the JSON, which would cause errors in the NSwag client when trying to parse again
	});

	const api = new SkylightClient(config.public.apiBaseSkylight, client);

	return { api };
}
