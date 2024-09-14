FROM node:18.17.1-alpine AS builder

ARG API_URL
ENV API_URL=$API_URL

WORKDIR /app
COPY . .
RUN npm ci 
RUN npm run build

# Apache2
FROM httpd:2.4-alpine AS production
ENV NODE_ENV production
COPY --from=builder /app/dist/ /usr/local/apache2/htdocs/
COPY entrypoint.sh /usr/local/bin/
RUN chmod +x /usr/local/bin/entrypoint.sh

EXPOSE 80

ENTRYPOINT ["/usr/local/bin/entrypoint.sh"]
