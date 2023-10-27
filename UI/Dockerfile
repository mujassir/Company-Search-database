# Use the official Node.js image as a base image
FROM node:16.18.0

# Set the working directory in the container
WORKDIR /app

# Copy the Angular app files to the container
COPY UI/ /app

# Install Angular CLI
RUN npm install -g @angular/cli

# Install app dependencies
RUN npm install

# Build the Angular app for production
RUN ng build

# Expose the port the app runs on
EXPOSE 4200

# Start the Angular app
CMD ["ng", "serve", "--host", "0.0.0.0"]