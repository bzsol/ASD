# NodeJS
FROM node:16-alpine as builder
WORKDIR /app
COPY . .
RUN npm ci 
RUN npm run build

# Apache2
FROM httpd:2.4-alpine as production
ENV NODE_ENV production
COPY --from=builder /app/dist /usr/local/apache2/htdocs/
EXPOSE 80
