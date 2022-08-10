# Kubernetes

## Feedback Loops

### Inner Loop

Whatever happens *before* we push the code to the repo.

### Outer Loop

Everything after we push our code.


## Kubernetes Architecture

> Create a cluster to run your software at scale.

"Clustering" - you have bunch of computers that you treat as one computer.

"Promise Theory" - "Desired State Configuration"

Describe what we want. What our desired world is like.

Kubernetes continually tracks the "actual state" vs "desired state"


### Nodes

Nodes are machines (real or virtual) that are part of the cluster.

### Control Plane Nodes
- Api 
    - HTTP/RESTful API
- Scheduler
    - watch the database for changes, and make it happen.
    - watches the "real state" and compares against database and corrects
    - "loop"
- Database (etcd)


### Worker Nodes




### "Pods"

Unit of deployment. These are the things that scheduler sends and runs on a node.

Has one (at least) and sometimes more containers (those are the whales).

If there is multiple containers in the pod, they are always deployed together to the same node.

"Localhost" 

Node is an actual machine
Pod is a "virtual" localhost on a node.


## Running Kubernetes

### Prod
- In the cloud (AWS, Azure, GKS, etc.)
- On Prem: OpenShift, of just use Kubernetes open source.
- K3S - For "Edge", lightweight stuff. 

### Locally (Developer Testing, etc.)
"Kuberenetes in Docker"
    - Docker Desktop
    - KIND
    - MiniKube
"Not In Docker"
    - K3S (Rancher)
    - Rancher Desktop
        - *also* includes Docker (emulated)
