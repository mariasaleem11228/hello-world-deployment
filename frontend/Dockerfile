FROM nginx:alpine

ARG CACHE_BUST=1
COPY index.html /usr/share/nginx/html/index.html
RUN echo "Busting cache with arg: $CACHE_BUST"

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
