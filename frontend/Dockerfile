FROM nginx:alpine

COPY index.html /usr/share/nginx/html/index.html

ARG CACHE_BUST=1

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
