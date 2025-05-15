import * as SignalR from '@microsoft/signalr';
import { AlertsHub } from '~/plugins/signal-r';

export interface AlertsHubCallbacks {
	notifyNewAlerts?: (input: NotifyNewAlertsInput) => void;
}

export interface NotifyNewAlertsInput {
	count: number;
}

export default function (callbacks: AlertsHubCallbacks): { hub: SignalR.HubConnection } {
	const hub = inject(AlertsHub) as SignalR.HubConnection;

	if (callbacks.notifyNewAlerts) {
		hub.on('NotifyNewAlertsAsync', callbacks.notifyNewAlerts);
	}

	return { hub };
}
