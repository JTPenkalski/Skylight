using Skylight.Application.Interfaces.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Clients.NationalWeatherService;

namespace Skylight.Tests.Infrastructure.Clients;

public class NationalWeatherServiceClientTests
{
    private const string PrepareGetActiveAlertsResponse_Should_ParseJson_TestData = """
        {
          "@context": [
              "https://geojson.org/geojson-ld/geojson-context.jsonld",
              {
                  "@version": "1.1",
                  "wx": "https://api.weather.gov/ontology#",
                  "@vocab": "https://api.weather.gov/ontology#"
              }
          ],
          "type": "FeatureCollection",
          "features": [
              {
                  "id": "https://api.weather.gov/alerts/urn:oid:2.49.0.1.840.0.907afeaae671d4ee00ff8c46735a08e24b091c58.001.1",
                  "type": "Feature",
                  "geometry": {
                      "type": "Polygon",
                      "coordinates": [
                          [
                              [
                                  -99.280000000000001,
                                  32.119999999999997
                              ],
                              [
                                  -99.239999999999995,
                                  32.259999999999998
                              ],
                              [
                                  -99.11999999999999,
                                  32.289999999999999
                              ],
                              [
                                  -99.11999999999999,
                                  32.100000000000001
                              ],
                              [
                                  -99.280000000000001,
                                  32.119999999999997
                              ]
                          ]
                      ]
                  },
                  "properties": {
                      "@id": "https://api.weather.gov/alerts/urn:oid:2.49.0.1.840.0.907afeaae671d4ee00ff8c46735a08e24b091c58.001.1",
                      "@type": "wx:Alert",
                      "id": "urn:oid:2.49.0.1.840.0.907afeaae671d4ee00ff8c46735a08e24b091c58.001.1",
                      "areaDesc": "Callahan, TX",
                      "geocode": {
                          "SAME": [
                              "048059"
                          ],
                          "UGC": [
                              "TXC059"
                          ]
                      },
                      "affectedZones": [
                          "https://api.weather.gov/zones/county/TXC059"
                      ],
                      "references": [],
                      "sent": "2024-05-25T17:27:00-05:00",
                      "effective": "2024-05-25T17:27:00-05:00",
                      "onset": "2024-05-25T17:27:00-05:00",
                      "expires": "2024-05-25T18:00:00-05:00",
                      "ends": "2024-05-25T18:00:00-05:00",
                      "status": "Actual",
                      "messageType": "Alert",
                      "category": "Met",
                      "severity": "Severe",
                      "certainty": "Observed",
                      "urgency": "Immediate",
                      "event": "Severe Thunderstorm Warning",
                      "sender": "w-nws.webmaster@noaa.gov",
                      "senderName": "NWS San Angelo TX",
                      "headline": "Severe Thunderstorm Warning issued May 25 at 5:27PM CDT until May 25 at 6:00PM CDT by NWS San Angelo TX",
                      "description": "SVRSJT\n\nThe National Weather Service in San Angelo has issued a\n\n* Severe Thunderstorm Warning for...\nSoutheastern Callahan County in west central Texas...\n\n* Until 600 PM CDT.\n\n* At 527 PM CDT, a severe thunderstorm was located near Cross Plains,\nmoving east at 25 mph.\n\nHAZARD...Ping pong ball size hail and 60 mph wind gusts.\n\nSOURCE...Radar indicated.\n\nIMPACT...People and animals outdoors will be injured. Expect hail\ndamage to roofs, siding, windows, and vehicles. Expect\nwind damage to roofs, siding, and trees.\n\n* This severe thunderstorm will remain over mainly rural areas of\nsoutheastern Callahan County.",
                      "instruction": "Remain alert for a possible tornado! Tornadoes can develop quickly\nfrom severe thunderstorms. If you spot a tornado go at once into the\nbasement or small central room in a sturdy structure.\n\nFor your protection move to an interior room on the lowest floor of a\nbuilding.\n\nA Tornado Watch remains in effect until 900 PM CDT for west central\nTexas.",
                      "response": "Shelter",
                      "parameters": {
                          "AWIPSidentifier": [
                              "SVRSJT"
                          ],
                          "WMOidentifier": [
                              "WUUS54 KSJT 252227"
                          ],
                          "eventMotionDescription": [
                              "2024-05-25T22:27:00-00:00...storm...269DEG...21KT...32.17,-99.14"
                          ],
                          "windThreat": [
                              "RADAR INDICATED"
                          ],
                          "maxWindGust": [
                              "60 MPH"
                          ],
                          "hailThreat": [
                              "RADAR INDICATED"
                          ],
                          "maxHailSize": [
                              "1.50"
                          ],
                          "tornadoDetection": [
                              "POSSIBLE"
                          ],
                          "BLOCKCHANNEL": [
                              "EAS",
                              "NWEM",
                              "CMAS"
                          ],
                          "EAS-ORG": [
                              "WXR"
                          ],
                          "VTEC": [
                              "/O.NEW.KSJT.SV.W.0265.240525T2227Z-240525T2300Z/"
                          ],
                          "eventEndingTime": [
                              "2024-05-25T23:00:00+00:00"
                          ]
                      }
                  }
              },
              {
                  "id": "https://api.weather.gov/alerts/urn:oid:2.49.0.1.840.0.0c878bd430ad53630ed6f026be82514bb1089b32.001.1",
                  "type": "Feature",
                  "geometry": {
                      "type": "Polygon",
                      "coordinates": [
                          [
                              [
                                  -78.340000000000003,
                                  35.719999999999999
                              ],
                              [
                                  -78.38000000000001,
                                  35.879999999999995
                              ],
                              [
                                  -78.280000000000015,
                                  35.939999999999998
                              ],
                              [
                                  -78.090000000000018,
                                  36.019999999999996
                              ],
                              [
                                  -78.010000000000019,
                                  35.689999999999998
                              ],
                              [
                                  -78.340000000000003,
                                  35.719999999999999
                              ]
                          ]
                      ]
                  },
                  "properties": {
                      "@id": "https://api.weather.gov/alerts/urn:oid:2.49.0.1.840.0.0c878bd430ad53630ed6f026be82514bb1089b32.001.1",
                      "@type": "wx:Alert",
                      "id": "urn:oid:2.49.0.1.840.0.0c878bd430ad53630ed6f026be82514bb1089b32.001.1",
                      "areaDesc": "Franklin, NC; Johnston, NC; Nash, NC; Wake, NC; Wilson, NC",
                      "geocode": {
                          "SAME": [
                              "037069",
                              "037101",
                              "037127",
                              "037183",
                              "037195"
                          ],
                          "UGC": [
                              "NCC069",
                              "NCC101",
                              "NCC127",
                              "NCC183",
                              "NCC195"
                          ]
                      },
                      "affectedZones": [
                          "https://api.weather.gov/zones/county/NCC069",
                          "https://api.weather.gov/zones/county/NCC101",
                          "https://api.weather.gov/zones/county/NCC127",
                          "https://api.weather.gov/zones/county/NCC183",
                          "https://api.weather.gov/zones/county/NCC195"
                      ],
                      "references": [],
                      "sent": "2024-05-25T18:27:00-04:00",
                      "effective": "2024-05-25T18:27:00-04:00",
                      "onset": "2024-05-25T18:27:00-04:00",
                      "expires": "2024-05-25T19:15:00-04:00",
                      "ends": "2024-05-25T19:15:00-04:00",
                      "status": "Actual",
                      "messageType": "Alert",
                      "category": "Met",
                      "severity": "Severe",
                      "certainty": "Observed",
                      "urgency": "Immediate",
                      "event": "Severe Thunderstorm Warning",
                      "sender": "w-nws.webmaster@noaa.gov",
                      "senderName": "NWS Raleigh NC",
                      "headline": "Severe Thunderstorm Warning issued May 25 at 6:27PM EDT until May 25 at 7:15PM EDT by NWS Raleigh NC",
                      "description": "SVRRAH\n\nThe National Weather Service in Raleigh has issued a\n\n* Severe Thunderstorm Warning for...\nSouthwestern Nash County in central North Carolina...\nEast central Wake County in central North Carolina...\nWest central Wilson County in central North Carolina...\nNortheastern Johnston County in central North Carolina...\nSouth central Franklin County in central North Carolina...\n\n* Until 715 PM EDT.\n\n* At 626 PM EDT, a severe thunderstorm was located over Zebulon, or\n18 miles south of Louisburg, moving east at 10 mph.\n\nHAZARD...60 mph wind gusts and quarter size hail.\n\nSOURCE...Radar indicated.\n\nIMPACT...Hail damage to vehicles is expected. Expect wind damage\nto roofs, siding, and trees.\n\n* Locations impacted include...\nZebulon, Bailey, Wendell, Spring Hope, Middlesex, Sims, Pilot,\nEmit, and Buckhorn Reservoir.",
                      "instruction": "For your protection move to an interior room on the lowest floor of a\nbuilding.",
                      "response": "Shelter",
                      "parameters": {
                          "AWIPSidentifier": [
                              "SVRRAH"
                          ],
                          "WMOidentifier": [
                              "WUUS52 KRAH 252227"
                          ],
                          "eventMotionDescription": [
                              "2024-05-25T22:26:00-00:00...storm...254DEG...9KT...35.84,-78.31"
                          ],
                          "windThreat": [
                              "RADAR INDICATED"
                          ],
                          "maxWindGust": [
                              "60 MPH"
                          ],
                          "hailThreat": [
                              "RADAR INDICATED"
                          ],
                          "maxHailSize": [
                              "1.00"
                          ],
                          "BLOCKCHANNEL": [
                              "EAS",
                              "NWEM",
                              "CMAS"
                          ],
                          "EAS-ORG": [
                              "WXR"
                          ],
                          "VTEC": [
                              "/O.NEW.KRAH.SV.W.0078.240525T2227Z-240525T2315Z/"
                          ],
                          "eventEndingTime": [
                              "2024-05-25T23:15:00+00:00"
                          ]
                      }
                  }
              }
          ],
          "title": "Current watches, warnings, and advisories",
          "updated": "2024-05-25T22:28:28+00:00"
        }
        """;

    private readonly NationalWeatherServiceClient client = new(null!);

    [Fact]
    public void PrepareGetActiveAlertsResponse_Should_ParseJson()
    {
        // Arrange / Act
        GetActiveAlertsResponse response = client.PrepareGetActiveAlertsResponse(PrepareGetActiveAlertsResponse_Should_ParseJson_TestData);

        // Assert
        Assert.Equal(2, response.AlertCollection.Alerts.Count);

        Assert.Equal("Current watches, warnings, and advisories", response.AlertCollection.Title);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T22:28:28+00:00"), response.AlertCollection.Updated);

        Alert alert1 = response.AlertCollection.Alerts[0];
        Assert.Equal("urn:oid:2.49.0.1.840.0.907afeaae671d4ee00ff8c46735a08e24b091c58.001.1", alert1.Id);
        Assert.Equal(AlertResponse.Shelter, alert1.Response);
        Assert.Equal("Callahan, TX", alert1.AreaDescription);
        Assert.Equal<string[]>(["TXC059"], alert1.ZoneIds);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T17:27:00-05:00"), alert1.Sent);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T17:27:00-05:00"), alert1.Effective);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T17:27:00-05:00"), alert1.Onset);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T18:00:00-05:00"), alert1.Expires);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T18:00:00-05:00"), alert1.Ends);
        Assert.Equal(AlertStatus.Actual, alert1.Status);
        Assert.Equal(AlertMessageType.Alert, alert1.MessageType);
        Assert.Equal(AlertSeverity.Severe, alert1.Severity);
        Assert.Equal(AlertCategory.Met, alert1.Category);
        Assert.Equal(AlertUrgency.Immediate, alert1.Urgency);
        Assert.Equal(AlertCertainty.Observed, alert1.Certainty);
        Assert.Equal("Severe Thunderstorm Warning", alert1.Event);
        Assert.Equal("NWS San Angelo TX", alert1.SenderName);
        Assert.Equal("Severe Thunderstorm Warning issued May 25 at 5:27PM CDT until May 25 at 6:00PM CDT by NWS San Angelo TX", alert1.Headline);
        Assert.Equal("SVRSJT\n\nThe National Weather Service in San Angelo has issued a\n\n* Severe Thunderstorm Warning for...\nSoutheastern Callahan County in west central Texas...\n\n* Until 600 PM CDT.\n\n* At 527 PM CDT, a severe thunderstorm was located near Cross Plains,\nmoving east at 25 mph.\n\nHAZARD...Ping pong ball size hail and 60 mph wind gusts.\n\nSOURCE...Radar indicated.\n\nIMPACT...People and animals outdoors will be injured. Expect hail\ndamage to roofs, siding, windows, and vehicles. Expect\nwind damage to roofs, siding, and trees.\n\n* This severe thunderstorm will remain over mainly rural areas of\nsoutheastern Callahan County.", alert1.Description);
        Assert.Equal("Remain alert for a possible tornado! Tornadoes can develop quickly\nfrom severe thunderstorms. If you spot a tornado go at once into the\nbasement or small central room in a sturdy structure.\n\nFor your protection move to an interior room on the lowest floor of a\nbuilding.\n\nA Tornado Watch remains in effect until 900 PM CDT for west central\nTexas.", alert1.Instruction);
        Assert.Equal(AlertResponse.Shelter, alert1.Response);

        Alert alert2 = response.AlertCollection.Alerts[1];
        Assert.Equal("urn:oid:2.49.0.1.840.0.0c878bd430ad53630ed6f026be82514bb1089b32.001.1", alert2.Id);
        Assert.Equal(AlertResponse.Shelter, alert2.Response);
        Assert.Equal("Franklin, NC; Johnston, NC; Nash, NC; Wake, NC; Wilson, NC", alert2.AreaDescription);
        Assert.Equal<string[]>(["NCC069", "NCC101", "NCC127", "NCC183", "NCC195"], alert2.ZoneIds);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T18:27:00-04:00"), alert2.Sent);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T18:27:00-04:00"), alert2.Effective);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T18:27:00-04:00"), alert2.Onset);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T19:15:00-04:00"), alert2.Expires);
        Assert.Equal(DateTimeOffset.Parse("2024-05-25T19:15:00-04:00"), alert2.Ends);
        Assert.Equal(AlertStatus.Actual, alert2.Status);
        Assert.Equal(AlertMessageType.Alert, alert2.MessageType);
        Assert.Equal(AlertSeverity.Severe, alert2.Severity);
        Assert.Equal(AlertCategory.Met, alert2.Category);
        Assert.Equal(AlertUrgency.Immediate, alert2.Urgency);
        Assert.Equal(AlertCertainty.Observed, alert2.Certainty);
        Assert.Equal("Severe Thunderstorm Warning", alert2.Event);
        Assert.Equal("NWS Raleigh NC", alert2.SenderName);
        Assert.Equal("Severe Thunderstorm Warning issued May 25 at 6:27PM EDT until May 25 at 7:15PM EDT by NWS Raleigh NC", alert2.Headline);
        Assert.Equal("SVRRAH\n\nThe National Weather Service in Raleigh has issued a\n\n* Severe Thunderstorm Warning for...\nSouthwestern Nash County in central North Carolina...\nEast central Wake County in central North Carolina...\nWest central Wilson County in central North Carolina...\nNortheastern Johnston County in central North Carolina...\nSouth central Franklin County in central North Carolina...\n\n* Until 715 PM EDT.\n\n* At 626 PM EDT, a severe thunderstorm was located over Zebulon, or\n18 miles south of Louisburg, moving east at 10 mph.\n\nHAZARD...60 mph wind gusts and quarter size hail.\n\nSOURCE...Radar indicated.\n\nIMPACT...Hail damage to vehicles is expected. Expect wind damage\nto roofs, siding, and trees.\n\n* Locations impacted include...\nZebulon, Bailey, Wendell, Spring Hope, Middlesex, Sims, Pilot,\nEmit, and Buckhorn Reservoir.", alert2.Description);
        Assert.Equal("For your protection move to an interior room on the lowest floor of a\nbuilding.", alert2.Instruction);
        Assert.Equal(AlertResponse.Shelter, alert2.Response);
    }
}
