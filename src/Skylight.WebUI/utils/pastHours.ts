export default function (pastHours: MaybeRef<number>): string[] {
	const now = new Date();
	const hours = [];

	for (let i = 0; i < unref(pastHours); i++) {
		const pastHour = new Date(now);
		pastHour.setHours(now.getHours() - i, 0, 0, 0);

		const formattedHour = pastHour.toLocaleTimeString('en-US', {
			hour: '2-digit',
			minute: '2-digit',
		});

		hours.unshift(formattedHour);
	}

	return hours;
}
