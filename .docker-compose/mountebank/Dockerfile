FROM node:13.12.0
RUN npm install -g mountebank@2.8.0
ENTRYPOINT ["mb"]
CMD ["start", "--configfile", "/imposters.ejs", "--allowInjection"]
COPY *.ejs .