/etc/hosts
minikube ip grafana
minikube ip warehouse

minikube addons enable metrics-server
minikube addons enable ingress
eval $(minikube docker-env)

kubectl create namespace monitoring
helm repo add prometheus-community https://prometheus-community.github.io/helm-charts
helm install --namespace monitoring prometheus prometheus-community/kube-prometheus-stack
kubectl config set-context --current --namespace=monitoring
kubectl apply -f grafana_deployment

kubectl config set-context --current --namespace=default

kubectl apply -f elastic_kibana_deployment

kubectl expose deployment kibana --type=LoadBalancer --name=kibana-minikube-service
minikube service kibana-minikube-service

appsettings.json
"ElasticConfiguration": {
"Uri": "http://(minikube ip)/elasticsearch/" //minikube ip
},

docker build -t warehouse:v4 -f Dockerfile .

kubectl apply -f warehouse_deployment
