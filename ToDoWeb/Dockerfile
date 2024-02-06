# Use the official Node.js image as the base image
FROM node:18 as build

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY ToDoWeb/package*.json ./

# Install project dependencies including the Angular CLI
RUN npm install

# Install the Angular CLI locally
RUN npm install -g @angular/cli

# Copy the entire project to the container
COPY . .

# Build the Angular app for production
RUN npm run build

# Use a smaller, production-ready image as the final image
FROM nginx:alpine

# Copy the production-ready Angular app to the Nginx webserver's root directory
COPY --from=build /app/dist/to-do-web /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]



# Stage 1: Build the Angular app
# FROM node:18 AS build
# WORKDIR /app
# COPY ToDoWeb/package.json ../../ToDoWeb/package-lock.json ./
# RUN npm ci
# COPY ToDoWeb/. .
# RUN npm run build -- --configuration production

# 2: Serve the Angular app with Nginx
# FROM nginx:1.23.4-alpine
# # COPY --from=build /app/dist/ToDoWeb /usr/share/nginx/html
# COPY ToDoWeb/nginx.conf /etc/nginx/conf.d/default.conf
# COPY entrypoint.sh /entrypoint.sh
# RUN chmod +x /entrypoint.sh
# CMD ["/entrypoint.sh"]
#ENTRYPOINT ["/bin/sh", "/entrypoint.sh"]