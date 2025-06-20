﻿using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertSender : BaseAuditableEntity
{
	public required string Code { get; set; }

	public required string Name { get; set; }
}
