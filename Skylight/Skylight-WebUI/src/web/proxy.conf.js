const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast", // TODO: How is this used and should it be updated?
    ],
    target: "https://localhost:7147",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
