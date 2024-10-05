FROM node:alpine

WORKDIR /usr/src/app

COPY . /usr/src/app

ARG NG_CLI_ANALYTICS="false"

RUN npm install -g @angular/cli

RUN npm install

RUN ng analytics off

CMD ["ng", "serve", "--host", "0.0.0.0", "--port", "80"]