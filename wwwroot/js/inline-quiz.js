(function(){
    // Minimal inline quiz renderer
    const evals = window.__EVALS || [];
    const evalList = document.getElementById('eval-list');
    const quizArea = document.getElementById('quiz-area');
    const quizTitle = document.getElementById('quiz-title');

    function findEval(id){ return evals.find(e=>e.Id==id); }

    function renderEvaluation(evaluation){
        quizTitle.textContent = evaluation.Titre;
        if(!evaluation.Questions || evaluation.Questions.length===0){
            quizArea.innerHTML = '<p>Aucune question disponible pour cette évaluation.</p>';
            return;
        }
        let html = '<form id="quiz-form">';
        evaluation.Questions.forEach((q, idx)=>{
            html += `<div class="question" data-qid="${q.Id}">`;
            html += `<div class="d-flex justify-content-between"><strong>Q${idx+1}:</strong><span>${q.Points} pts</span></div>`;
            html += `<p>${q.Texte}</p>`;
            if(q.OptionsReponse && q.OptionsReponse.length>0){
                q.OptionsReponse.forEach(opt=>{
                    const name = 'q_'+q.Id;
                    html += `<div class="form-check"><input class="form-check-input" type="radio" name="${name}" value="${opt.Id}" id="opt_${opt.Id}"><label class="form-check-label" for="opt_${opt.Id}">${opt.Texte}</label></div>`;
                });
            } else {
                html += `<div><input type="text" class="form-control" name="q_${q.Id}" placeholder="Votre réponse"/></div>`;
            }
            html += '</div>';
        });
        html += '<div class="mt-2"><button type="submit" class="btn btn-success">Soumettre</button> <button type="button" id="start-session-btn" class="btn btn-outline-primary">Enregistrer tentative</button></div>';
        html += '</form>';
        quizArea.innerHTML = html;

        // attach handlers
        const form = document.getElementById('quiz-form');
        form.addEventListener('submit', function(e){
            e.preventDefault();
            // For now, collect answers and show a small summary (client-side)
            const formData = new FormData(form);
            const answers = {};
            for(const pair of formData.entries()){
                answers[pair[0]] = pair[1];
            }
            quizArea.insertAdjacentHTML('beforeend','<div class="alert alert-info mt-2">Réponses enregistrées localement. Cliquez "Enregistrer tentative" pour créer une tentative côté serveur.</div>');
            window.__LAST_ANSWERS = answers;
        });

        const startBtn = document.getElementById('start-session-btn');
        startBtn.addEventListener('click', function(){
            // POST to /Dashboard/StartSession to create a tentative server-side
            fetch('/Dashboard/StartSession', {
                method: 'POST',
                headers: { 'Content-Type':'application/x-www-form-urlencoded' },
                body: 'evaluationId=' + encodeURIComponent(evaluation.Id)
            }).then(resp=>{
                if(resp.redirected){
                    window.location = resp.url; // follow redirect
                } else {
                    quizArea.insertAdjacentHTML('beforeend','<div class="alert alert-success mt-2">Tentative créée. Rechargez la page pour voir l\'historique.</div>');
                }
            }).catch(err=>{
                quizArea.insertAdjacentHTML('beforeend','<div class="alert alert-danger mt-2">Erreur lors de la création de la tentative.</div>');
            });
        });
    }

    // Attach click handlers to evaluation buttons
    document.querySelectorAll('.eval-btn').forEach(btn=>{
        btn.addEventListener('click', function(){
            // toggle active styling
            document.querySelectorAll('.list-group-item.eval-btn').forEach(b=>b.classList.remove('active'));
            btn.classList.add('active');

            const id = btn.getAttribute('data-evalid');
            const evaluation = findEval(Number(id));
            if(evaluation) renderEvaluation(evaluation);
        });
    });
})();

// Tab handling: initialize tabs and activate panels
(function(){
    function showTab(name){
        document.querySelectorAll('#dashboard-tabs .nav-link').forEach(a=>{
            a.classList.toggle('active', a.getAttribute('data-tab')===name);
        });
        document.querySelectorAll('.tab-panel').forEach(p=>{
            p.classList.toggle('d-none', p.id !== 'tab-'+name);
        });
    }

    document.querySelectorAll('#dashboard-tabs .nav-link').forEach(a=>{
        a.addEventListener('click', function(e){
            e.preventDefault();
            const t = a.getAttribute('data-tab');
            showTab(t);
        });
    });

    // default tab
    showTab('dashboard');
})();
