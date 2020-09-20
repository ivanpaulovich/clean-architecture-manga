FROM node:latest
# Create app directory
WORKDIR /usr/src/app
# Install app dependencies
COPY package*.json ./

RUN npm install
# Copy app source code
COPY . .

ARG ENV

RUN if [ "$ENV" = "Development" ]; then echo "Building for Development"; rm .env; mv .env.vs.debug .env; else echo "Building for Production"; fi

#Expose port and start application
EXPOSE 3000
CMD ["npm", "start"]