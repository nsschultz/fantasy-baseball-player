async function check(r) {
  check_all(r, ['/database_health', '/export_health', '/merge_health', '/projection_health']);
}

async function check_all(r, subs) {
  let results = await Promise.all(subs.map(uri => r.subrequest(uri)));
  let response = results.map(reply => ({ 
    uri:  reply.uri, 
    code: reply.status
  }));
  r.return(Math.max(response.map((res) => res.code)), JSON.stringify(response));
}

export default {check};