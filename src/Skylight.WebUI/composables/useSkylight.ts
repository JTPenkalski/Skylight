import { SkylightClient } from '~/clients/Skylight';
import { SkylightApi } from '~/plugins/skylight';

export default function (): { api: SkylightClient } {
	const api = inject(SkylightApi) as SkylightClient;

	return { api };
}
