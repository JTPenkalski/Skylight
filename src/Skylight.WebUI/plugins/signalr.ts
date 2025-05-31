import * as SignalR from '@microsoft/signalr';
import type { RuntimeConfig } from 'nuxt/schema';

export const AlertsHub = Symbol() as InjectionKey<SignalR.HubConnection>;

export default defineNuxtPlugin((nuxtApp) => {
	nuxtApp.vueApp.use((app) => {
		const config: RuntimeConfig = useRuntimeConfig();
		const hubUrl: string = `${config.public.apiBaseSkylight}/hub/alerts`;

		const hub: SignalR.HubConnection = new SignalR.HubConnectionBuilder()
			.withUrl(hubUrl, {
				withCredentials: false,
			})
			.withAutomaticReconnect()
			.configureLogging(SignalR.LogLevel.Information)
			.build();

		if (config.public.logging.hubs) {
			hub.onclose((error) => {
				if (error) {
					console.error(`Alerts Hub closing. Potential error: ${error}`);
				}
			});

			hub.onreconnecting((error) => {
				if (error) {
					console.error(`Alerts Hub reconnecting. Potential error: ${error}`);
				}
			});

			hub.onreconnected(() => {
				console.error('Alerts Hub reconnected!');
			});
		}

		hub
			.start()
			.then(() => console.log(`Successfully connected to SignalR Hub at ${hubUrl}.`))
			.catch((error) => console.error(`Error connecting to SignalR Hub at ${hubUrl}: ${error}`));

		app.provide(AlertsHub, hub);
	});
});
