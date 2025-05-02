export default function (date: MaybeRef<Date>): string {
	return new Date(unref(date)).toLocaleString('en-US', {
		year: 'numeric',
		month: 'long',
		day: 'numeric',
		hour: 'numeric',
		minute: 'numeric',
		hour12: true,
	});
}
