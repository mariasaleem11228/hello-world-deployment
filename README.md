# Hello World Deployment 

## Overview
This project demonstrates a complete CI/CD pipeline for deploying a Dockerized application composed of a .NET backend and a static frontend. The deployment is fully automated using GitHub Actions and targets an EC2 VM using secure SSH and Docker Compose.

## Deployment Architecture 

```
GitHub Push
   ↓
GitHub Actions (CI/CD)
   ↓
Build & Push Images → Docker Hub
   ↓
SSH to EC2 → docker-compose up
   ↓
Health Check OK? → Done
             ↓
            Rollback → Use previous version

Ubuntu EC2 VM:
├── frontend (NGINX serving static HTML)
└── backend (.NET Minimal API)

```

## Technologies Used
- **.NET 8** for backend API
- **NGINX** for serving static frontend
- **Docker** and **Docker Compose**
- **GitHub Actions** for CI/CD
- **EC2 Ubuntu VM** for hosting the app

## Repository Structure
```
hello-world-deployment/
├── backend/               # .NET Minimal API
│   ├── Dockerfile
│   └── Program.cs
├── frontend/              # Static HTML + Docker
│   ├── Dockerfile
│   └── index.html
├── docker-compose.yml     # Defines backend & frontend services
└── .github/workflows/     # GitHub Actions workflow (ci-cd.yml)
```

## CI/CD Pipeline (GitHub Actions)
### Trigger:
- On push or merged pull request to same branch

### Build Steps:
- Checkout code
- Log in to Docker Hub using secrets
- Build and push Docker images (frontend & backend)
- Optional: run .NET tests

### Deploy Steps:
- Use SSH key (GitHub secret)
- SSH into EC2
- Pull latest code and images
- Run `docker-compose up -d`
-	Wait for containers to start
-	Perform health checks on frontend and backend services
-	If health checks fail:
	   - Roll back to previous image version
	   - Restart containers with stable version


## Secrets Required
- `DOCKERHUB_USERNAME`
- `DOCKERHUB_TOKEN`
- `EC2_SSH_KEY` (private SSH key for VM access)

## How to Run
1. Push or merge into main branch
2. GitHub Actions triggers the CI/CD pipeline
3.	Docker images are built, versioned, and pushed to Docker Hub
4. Application is deployed to the EC2 instance
5.	If the deployment fails health checks, the pipeline automatically rolls back to the previous version
6. Access the app via the EC2 public IP
   - Example:
     - `http://<EC2-IP>/` (Frontend)
     - `http://<EC2-IP>:5000/helloworld` (Backend API)



