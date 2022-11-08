async function check(r) {
  check_all(r, [
    "/database_health",
    "/export_health",
    "/merge_health",
    "/projection_health",
  ]);
}

async function check_all(r, subs) {
  let results = await Promise.all(subs.map((uri) => r.subrequest(uri)));
  for (var i = 0; i < results.length; i++) {
    if (results[i].status != 200) {
      r.return(
        results[i].status,
        JSON.stringify({ uri: results[i].uri, code: results[i].status })
      );
      return;
    }
  }
  r.return(200, "Healthy");
}

export default { check };
