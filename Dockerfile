FROM nschultz/base-nginx-runner:0.5.3
COPY fantasy-baseball-player/nginx.conf /etc/nginx/nginx.conf
COPY fantasy-baseball-player/default.conf /etc/nginx/conf.d/