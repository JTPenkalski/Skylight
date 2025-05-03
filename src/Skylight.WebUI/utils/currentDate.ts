export default function (): string {
	const date = new Date();

	const year = date.getFullYear();
	const month = String(date.getMonth() + 1).padStart(2, '0');
	const day = String(date.getDate()).padStart(2, '0');
	const hours = String(date.getHours()).padStart(2, '0');
	const minutes = String(date.getMinutes()).padStart(2, '0');
	const seconds = String(date.getSeconds()).padStart(2, '0');
	const offsetMinutes = date.getTimezoneOffset();
	const offsetHours = Math.abs(Math.floor(offsetMinutes / 60))
		.toString()
		.padStart(2, '0');
	const offsetMins = Math.abs(offsetMinutes % 60)
		.toString()
		.padStart(2, '0');
	const offsetSign = offsetMinutes > 0 ? '-' : '+';
	const offset = `${offsetSign}${offsetHours}:${offsetMins}`;

	return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}${offset}`;
}
